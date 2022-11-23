from socket import *
from time import sleep
import random
import json

serverName = '255.255.255.255'
serverPort = 12000
sensorName = "MoveSpeedTrap"

clientSocket = socket(AF_INET, SOCK_DGRAM)
clientSocket.setsockopt(SOL_SOCKET, SO_BROADCAST, 1)

while True:
    speed = random.randint(20, 80)
    message = {"sensorName": sensorName, "speed": speed}
    clientSocket.sendto(json.dumps(message).encode(), (serverName, serverPort))
    print("Sent message: " + json.dumps(message))
    sleep(0.5)
clientSocket.close()
