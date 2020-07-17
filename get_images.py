import requests
import os
import shutil
import json
import time

SEARCH_URL = "https://oauth.reddit.com/r/Kombucha/search.json"
CLIENT_SECRET = os.environ["REDDIT_CLIENT_SECRET"]
CLIENT_ID = os.environ["REDDIT_CLIENT_ID"]
ACCESS_TOKEN_URL = "https://www.reddit.com/api/v1/access_token"

default_headers = {"User-Agent": "boochbot-0.0.1"}


def get_access_token():
    client_auth = requests.auth.HTTPBasicAuth(CLIENT_ID, CLIENT_SECRET)
    response = requests.post(
        ACCESS_TOKEN_URL,
        auth=client_auth,
        data={"grant_type": "client_credentials"},
        headers=default_headers,
    )

    return response.json()["access_token"]


def request_posts(after, access_token):
    response = requests.get(
        SEARCH_URL,
        params={"q": "flair:mold!", "restrict_sr": "on", "after": after},
        headers={**default_headers, "Authorization": "Bearer {}".format(access_token)},
    )

    return response.json()


def download_file(url, path):
    with requests.get(url, headers=default_headers, stream=True) as r:
        with open(path, "wb") as f:
            shutil.copyfileobj(r.raw, f)

    return path


after = None
access_token = get_access_token()
for page in range(20):
    body = request_posts(after, access_token)
    for child in body["data"]["children"]:
        post = child["data"]
        if post.get("post_hint") != "image":
            continue

        save_to = None
        if post["link_flair_text"] == "mold!":
            save_to = "moldy"
        elif post["link_flair_text"] == "not mold":
            save_to = "healthy"
        if not save_to:
            continue

        dir_path = "images/{}".format(save_to)
        with open("{}/{}.json".format(dir_path, post["id"]), "w") as json_file:
            json.dump(post, json_file, indent=2)
        download_file(post["thumbnail"], "{}/{}.jpg".format(dir_path, post["id"]))

    after = body["data"]["after"]
    # Rate limited to 60 requests/min
    time.sleep(1)
