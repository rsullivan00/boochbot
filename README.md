# BoochBot

Contains scripts to support BoochBot--a bot for classifying images of hombrewed
kombucha as moldy or healthy.


## Things in here

- Azure chatbot version of Boochbot (`azure-bot/`)
  - Available at https://ricksullivan.net/boochbot
- Python scripts for scraping training images from /r/kombucha (`get_images.py`)
- Python scripts for training a classification model (`model.py`)


## Context

One of the first quarantine hobbies I picked up at the beginning of COVID 19 was
homebrewing kombucha. The [kombucha subreddit](https://reddit.com/r/kombucha) is
a great resource for getting started, so I subscribed and started watching posts
there.

A few times a week, there are always questions where people post pictures of
their kombucha and are concerned about it looking weird. Even healthy kombucha
can look super weird, but it's generally okay as long as there isn't mold
present on the surface. I figured I could train a basic CNN to classify images
of the top of brewing kombucha as moldy or not, using past Reddit posts, and
create a bot to automatically respond to these posts with the results.

Right now, I only have ~120 images of each of the `moldy`/`negative` classes, so
the model is very inaccurate. With a large amount of data augmentation, I've
been able to get around 70% accuracy on my dataset. Using Microsoft's automatic
ML tool at [https://www.customvision.ai](https://www.customvision.ai]), the
model is around 65% accurate.


## Next steps

- Add a Reddit response bot hooked up to the model
- Gather more data and retrain for more accuracy
