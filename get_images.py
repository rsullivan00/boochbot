import requests
import os
import shutil

API_URL = 'https://www.googleapis.com/customsearch/v1'
API_KEY = os.environ['GOOGLE_API_KEY']
API_CX = os.environ['GOOGLE_API_CX']


def request_images(start):
    response = requests.get(API_URL,
                            params={
                                'key': API_KEY,
                                'cx': API_CX,
                                'q': 'kombucha first fermentation',
                                'searchType': 'image',
                                'start': start,
                                'fields': 'items(image)'
                            })
    return response.json()


def download_file(url, path):
    with requests.get(url, stream=True) as r:
        with open(path, 'wb') as f:
            shutil.copyfileobj(r.raw, f)

    return path


start = 200
end = 300
while start < end:
    body = request_images(start)
    import pdb; pdb.set_trace()
    for i, item in enumerate(body['items']):
        idx = start + i
        download_file(item['image']['thumbnailLink'],
                      'images/healthy/{}.jpg'.format(idx))

    start = body['queries']['nextPage'][0]['startIndex']
