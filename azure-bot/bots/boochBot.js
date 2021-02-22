const { ActionTypes } = require('botframework-schema')
const { ActivityTypes, ActivityHandler, MessageFactory } = require('botbuilder')
const fetch = require('node-fetch')

class BoochBot extends ActivityHandler {
  constructor(conversationState, userState, dialog) {
    super(conversationState, userState, dialog)
    this.onMembersAdded(async (context, next) => {
      await this.sendWelcomeMessage(context)

      // By calling next() you ensure that the next BotHandler is run.
      await next()
    })

    this.onMessage(async (context, next) => {
      if (context.activity.text) {
        await this.handleTextMessage(context)
      } else if (context.activity.attachments.length > 0) {
        await this.handleAttachment(context)
      }

      await next()
    })
  }

  async handleTextMessage(context) {
    const text = context.activity.text

    if (text === 'starting') {
      await this.sendStartingInfo(context)
    } else if (text === 'mold') {
      await this.sendMoldInfo(context)
    } else if (text === 'carbonation') {
      await this.sendCarbonationInfo(context)
    } else {
      await context.sendActivity(
        `I don't know how to respond to "${text}", sorry.`
      )
      await this.sendSuggestedActions(context)
    }
  }

  async handleAttachment(context) {
    const attachment = context.activity.attachments[0]

    const response = await fetch(process.env.BOOCHBOT_PREDICTION_URL, {
      method: 'POST',
      body: JSON.stringify({
        Url: attachment.contentUrl,
      }),
      headers: {
        'Content-Type': 'application/json',
        'Prediction-Key': process.env.BOOCHBOT_PREDICTION_KEY,
      },
    })

    if (!response.ok) {
      await context.sendActivities([
        { type: ActivityTypes.Typing },
        { type: 'delay', value: 1000 },
        {
          type: ActivityTypes.Message,
          text: 'Something went wrong with processing that file.',
        },
      ])
      return
    }

    const json = await response.json()
    const { probability, tagName } = json.predictions[0]
    const tagDescriptor = tagName === 'mold' ? 'moldy' : 'not moldy'
    await context.sendActivities([
      { type: ActivityTypes.Typing },
      { type: 'delay', value: 1000 },
      {
        type: ActivityTypes.Message,
        text: `I'm ${Math.round(
          probability * 100
        )}% sure that your kombucha is ${tagDescriptor}.`,
      },
    ])
  }

  async sendStartingInfo(context) {
    await context.sendActivities([
      { type: ActivityTypes.Typing },
      { type: 'delay', value: 1000 },
      {
        type: ActivityTypes.Message,
        text: 'This is my favorite recipe for starting out',
      },
      // TODO: Typing/delay seem to delay all messages in this batch up front,
      // not sequentially
      // This might just be an emulator problem--the requests seem to come in,
      // but the UI doesn't render the new messages.
      { type: ActivityTypes.Typing },
      { type: 'delay', value: 1000 },
      {
        type: ActivityTypes.Message,
        text: `
Ingredient | Imperial | Metric
---- | --- | ---
Water (preferably filtered to remove chlorine/chloramine) | 1 quart | 1 liter
Sugar (start with plain white sugar, then experiment with others) | 1/4 cup | 70 grams
Tea (start with plain black tea, then experiment with others) | 3 bags or 1 Tablespoon | 7 grams
Raw Kombucha/Starter Liquid | 1 cup | 0.2 Liter`,
      },
      { type: ActivityTypes.Typing },
      { type: 'delay', value: 3000 },
      {
        type: ActivityTypes.Message,
        text: `
Once you have all the ingredients,

1. Brew the sweet tea. Let it cool until it reaches room temperature (below 90F/32C). Alternatively, brew a smaller batch of hot sweet tea and add cold water to bring it closer to room temperature.
1. Add the starter liquid (this can just be kombucha from the previous batch) in your brewing vessel.
1. Cover the vessel with a fine breathable cloth (or coffee filters) that will let air pass through but not bugs or dust. Most cheesecloth is not suitable as the holes are too big! Use a rubber band to secure the cloth tightly.
1. Leave it to sit in a warm corner of the house out of direct sunlight. Minimum recommended temperature is 65F/18C, with optimum around 80F/27C. After about a week, you can begin tasting it. Does it taste too sweet? Leave it alone for a while longer. Does it taste perfect? Bottling time! Brew time depends ENTIRELY on preference.
1. Bottle the kombucha, adding either fruit juice, fruit, or sugar (don't use square bottles). This bottling process is also known as secondary fermentation or "2F" and will help create carbonation/fizz. If adding fruit juice, fill 10-20% of the bottle with juice and cover with kombucha. If adding sugar, start out with 1 teaspoon/4 grams per bottle (450mL/16oz), and adjust based on experimentation. If fruit - again, experiment, or check what other people have done by scrolling through the posts or checking the wiki article on flavoring. If you need flavour inspiration, check this chart. Remember to reserve some of your brew to use as starter liquid for your next batch.
1. Let the bottles sit at room temperature for anywhere between 1 and 7 days, to create enough fizz. It depends on amount of sugar, the strength of your kombucha etc. For more information about timing this process and avoiding bottle bombs, check the carbonation wiki article.
1. Refrigerate the finished bottles to stop the fermentation process and allow more CO2 to dissolve into the liquid.`,
      },
      { type: ActivityTypes.Typing },
      { type: 'delay', value: 2000 },
      {
        type: ActivityTypes.Message,
        text:
          'If you want more information, check out [this link](https://www.reddit.com/r/kombucha/wiki/how_to_start).',
      },
    ])
  }

  async sendMoldInfo(context) {
    await context.sendActivities([
      { type: ActivityTypes.Typing },
      { type: 'delay', value: 1000 },
      {
        type: ActivityTypes.Message,
        text:
          "Mold is typically fuzzy. If your kombucha has a shiny or bubbly looking pellicle, you're probably good to go.",
      },
      { type: ActivityTypes.Typing },
      { type: 'delay', value: 1000 },
      {
        type: ActivityTypes.Message,
        text:
          "If you want, you can upload a picture of the top of your kombucha and I can try to determine if it's moldy.",
      },
      { type: 'delay', value: 500 },
    ])
  }

  async sendCarbonationInfo(context) {
    await context.sendActivities([
      { type: ActivityTypes.Typing },
      { type: 'delay', value: 1000 },
      {
        type: ActivityTypes.Message,
        text: '[Read this](https://www.reddit.com/r/kombucha/wiki/carbonation)',
      },
    ])
  }

  async sendWelcomeMessage(context) {
    await context.sendActivity(
      "Hi there! I'm BoochBot, I can answer questions about homebrewing kombucha."
    )
    await this.sendSuggestedActions(context)
  }

  async sendSuggestedActions(turnContext) {
    const cardActions = [
      {
        type: ActionTypes.PostBack,
        title: 'Getting Started',
        value: 'starting',
        imageAltText: 'Getting Started',
      },
      {
        type: ActionTypes.PostBack,
        title: 'Mold',
        value: 'mold',
        imageAltText: 'Mold',
      },
      {
        type: ActionTypes.PostBack,
        title: 'Carbonation',
        value: 'carbonation',
        imageAltText: 'Carbonation',
      },
    ]

    var reply = MessageFactory.suggestedActions(
      cardActions,
      'Choose a topic to ask about:'
    )
    await turnContext.sendActivity(reply)
  }
}

module.exports.BoochBot = BoochBot
