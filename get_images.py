import requests
import os
import json

API_URL = 'https://www.googleapis.com/customsearch/v1'
API_KEY = os.environ['GOOGLE_API_KEY']
API_CX = os.environ['GOOGLE_API_CX']


def get_images(start=0):
    response = requests.get(API_URL,
                            params={
                                key: API_KEY,
                                xc: API_CX,
                                q: 'moldy kombucha',
                                searchType: 'image',
                                start: start
                            })
    return json.loads(response.body)
