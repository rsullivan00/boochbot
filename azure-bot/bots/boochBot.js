const { ActionTypes } = require('botframework-schema')
const { ActivityHandler, MessageFactory } = require('botbuilder')

class BoochBot extends ActivityHandler {
  constructor(conversationState, userState, dialog) {
    super(conversationState, userState, dialog)
    this.onMembersAdded(async (context, next) => {
      await this.sendWelcomeMessage(context)

      // By calling next() you ensure that the next BotHandler is run.
      await next()
    })

    this.onMessage(async (context, next) => {
      const text = context.activity.text

      if (text === 'starting') {
        await context.sendActivity('Chose starting')
      } else if (text === 'mold') {
        await context.sendActivity('Chose mold')
      } else if (text === 'carbonation') {
        await context.sendActivity('Chose carbonation')
      } else {
        await context.sendActivity(
          `I don't know how to respond to "${text}", sorry.`
        )
        await this.sendSuggestedActions(context)
      }
    })
  }

  async sendWelcomeMessage(context) {
    const membersAdded = context.activity.membersAdded
    const member = membersAdded[membersAdded.length - 1]
    const name = member.name || 'there'
    await context.sendActivity(
      `Hi ${name}! I'm BoochBot, I can answer questions about homebrewing kombucha.`
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
