from socket import *
import requests
import json

serverPort = 12000
serverSocket = socket(AF_INET, SOCK_DGRAM)
api_url = "http://localhost:5069/api/SpeedTraps"
headers = {'Content-type': 'application/json'}

serverAddress = ('', serverPort)

serverSocket.bind(serverAddress)
print("The server is ready")
while True:
    message, clientAddress = serverSocket.recvfrom(2048)
    decoded_message = message.decode()
    print(decoded_message)
    # Using data and headers instead of json, as the data is already json encoded, using json= would
    # double encode it, and would not be a valid object.
    response = requests.post(api_url, data=decoded_message, headers=headers)
    print(response.json())

