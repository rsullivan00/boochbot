import tensorflow as tf
from tensorflow import keras
from tensorflow.keras import layers
import numpy as np

import os

image_size = (150, 150)
input_shape = image_size + (3,)
batch_size = 32
image_dir = "original-images"

train_ds = tf.keras.preprocessing.image_dataset_from_directory(
    image_dir,
    validation_split=0.2,
    subset="training",
    seed=1337,
    image_size=image_size,
    batch_size=batch_size,
)
val_ds = tf.keras.preprocessing.image_dataset_from_directory(
    image_dir,
    validation_split=0.2,
    subset="validation",
    seed=1337,
    image_size=image_size,
    batch_size=batch_size,
)

data_augmentation = keras.Sequential(
    [
        layers.experimental.preprocessing.RandomFlip("horizontal"),
        layers.experimental.preprocessing.RandomTranslation(
            height_factor=0.1, width_factor=0.1
        ),
        layers.experimental.preprocessing.RandomRotation(0.1),
        layers.experimental.preprocessing.RandomContrast(0.1),
    ]
)

# https://keras.io/guides/transfer_learning/
base_model = keras.applications.Xception(
    weights="imagenet",  # Load weights pre-trained on ImageNet.
    input_shape=input_shape,
    include_top=False,
)

base_model.trainable = False

inputs = keras.Input(shape=input_shape)
x = data_augmentation(inputs)
# Pre-trained Xception weights requires that input be normalized
# from (0, 255) to a range (-1., +1.), the normalization layer
# does the following, outputs = (inputs - mean) / sqrt(var)
norm_layer = keras.layers.experimental.preprocessing.Normalization()
mean = np.array([127.5] * 3)
var = mean ** 2
# Scale inputs to [-1, +1]
x = norm_layer(x)
norm_layer.set_weights([mean, var])

# The base model contains batchnorm layers. We want to keep them in inference mode
# when we unfreeze the base model for fine-tuning, so we make sure that the
# base_model is running in inference mode here.
x = base_model(x, training=False)
x = keras.layers.GlobalAveragePooling2D()(x)
x = keras.layers.Dropout(0.2)(x)  # Regularize with dropout
outputs = keras.layers.Dense(1)(x)
model = keras.Model(inputs, outputs)
keras.utils.plot_model(model, show_shapes=True)

epochs = 10

model.compile(
    optimizer=keras.optimizers.Adam(1e-3),
    loss=keras.losses.BinaryCrossentropy(from_logits=True),
    metrics=[keras.metrics.BinaryAccuracy()],
)


first_fit = model.fit(train_ds, epochs=epochs, validation_data=val_ds,)

# Unfreeze the base_model. Note that it keeps running in inference mode
# since we passed `training=False` when calling it. This means that
# the batchnorm layers will not update their batch statistics.
# This prevents the batchnorm layers from undoing all the training
# we've done so far.
base_model.trainable = True
model.summary()

model.compile(
    optimizer=keras.optimizers.Adam(1e-5),  # Low learning rate
    loss=keras.losses.BinaryCrossentropy(from_logits=True),
    metrics=[keras.metrics.BinaryAccuracy()],
)

epochs = 10
final_fit = model.fit(train_ds, epochs=epochs, validation_data=val_ds)

train_accuracy_history = (
    first_fit.history["binary_accuracy"] + final_fit.history["binary_accuracy"]
)
eval_accuracy_history = (
    first_fit.history["val_binary_accuracy"] + final_fit.history["val_binary_accuracy"]
)

import matplotlib.pyplot as plt


plt.plot(
    range(1, len(train_accuracy_history) + 1), train_accuracy_history, label="train"
)
plt.plot(range(1, len(eval_accuracy_history) + 1), eval_accuracy_history, label="eval")
plt.xlabel("Epochs")
plt.ylabel("Accuracy")
plt.legend()

plt.savefig("accuracy.png")
plt.show()
