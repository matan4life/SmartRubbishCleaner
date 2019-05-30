import requests
import os
import math
import random
import datetime

deviceId = 2
url = "http://eac60d2b.ngrok.io/api/"
factoryId = 1
factory = requests.get(url+"factories/"+str(factoryId)).json()
accumulated = 0
v = 0
point = {
	'latitude': 50.014796,
	'longtitude': 36.228482
}

def getRadians(angle):
	return angle*math.PI/180.0

def getDistance(long1, long2, lat1, lat2):
	return math.acos(math.sin(lat1)*math.sin(lat2) + math.cos(lat1)*math.cos(lat2)*math.cos(long1-long2))*6400.0
	
def CalculateSpeed(lat, long):
	distance = getDistance(point['longtitude'], long, point['latitude'], lat)
	return distance * 6.0

def Move(long, lat, type, id):
	global point
	distance = getDistance(point['longtitude'], long, point['latitude'], lat)
	v = CalculateSpeed(long, lat)
	if type == "can":
		print("Moving to can number " + str(id))
	else:
		print("Moving to factory number " + str(id))
	i=0.0
	while i<=(10000000.0*distance/v):
		i+=1
	point = {'latitude': lat, 'longtitude': long}

def GetRubbish(id):
	global accumulated
	try:
		r=requests.get(url+"/devices/"+str(id))
	except requests.ConnectionError as e:
		print(e)
		return
	max = r.json()['maxWeight']
	print("Serving can number "+str(id))
	current = random.randint(0, max)
	if max-accumulated<current:
		while max-accumulated<current:
			current = random.randint(0, max)
	print("Amount of plastic rubbish: "+str(current))
	accumulated+=current
	print("Sending information...")
	cleaning = {
		"amount": current,
		"date": datetime.datetime.now().isoformat(),
		"rubbishType": "Plastic",
		"deviceId": deviceId,
		"factory" :{
			"factoryId": factory['factoryId'],
			"longtitude": factory['longtitude'],
			"latitude": factory['latitude']
		}
	}
	response = sendCleaning(cleaning)
	if response != 201:
		print("Request failed!")
	else:
		print("Request succeed!")
	current = random.randint(0, max)
	if max-accumulated<current:
		while max-accumulated<current:
			current = random.randint(0, max)
	print("Amount of paper rubbish: "+str(current))
	accumulated+=current
	print("Sending information...")
	cleaning = {
		"amount": current,
		"date": datetime.datetime.now().isoformat(),
		"rubbishType": "Paper",
		"deviceId": deviceId,
		"factory" :{
			"factoryId": factory['factoryId'],
			"longtitude": factory['longtitude'],
			"latitude": factory['latitude']
		}
	}
	response = sendCleaning(cleaning)
	if response != 201:
		print("Request failed!")
	else:
		print("Request succeed!")
	current = random.randint(0, max)
	if max-accumulated<current:
		while max-accumulated<current:
			current = random.randint(0, max)
	print("Amount of glass rubbish: "+str(current))
	accumulated+=current
	print("Sending information...")
	cleaning = {
		"amount": current,
		"date": datetime.datetime.now().isoformat(),
		"rubbishType": "Glass",
		"deviceId": deviceId,
		"factory" :{
			"factoryId": factory['factoryId'],
			"longtitude": factory['longtitude'],
			"latitude": factory['latitude']
		}
	}
	response = sendCleaning(cleaning)
	if response != 201:
		print("Request failed!")
	else:
		print("Request succeed!")
	print ("Totally acquainted: " + str(accumulated))
		
def getCans(id):
	controller="/trashcans"
	try:
		r = requests.get(url+controller)
	except requests.ConnectionError as e:
		print(e)
		return
	data = r.json()
	cans = []
	for i in range(0, len(data)):
		if data[i]['deviceId'] == id:
			cans.append(data[i])
	return cans

def sendCleaning(cleaning):
	try:
		r = requests.post(url+"/cleanings", json=cleaning)
	except requests.ConnectionError as e:
		print(e)
		return
	return r.status_code

def LoadRubbish(id):
	accumulated=0

def main():
	print("Start")
	cans = getCans(deviceId)
	numbers = [i['trashCanId'] for i in cans]
	print("Cans which are served now:" + str(numbers))
	for i in range(0, len(cans)):
		Move(cans[i]['longtitude'], cans[i]['latitude'], "can", cans[i]['trashCanId'])
		GetRubbish(deviceId)
	Move(factory['longtitude'], factory['latitude'], "factory", factoryId)
	LoadRubbish(factoryId)
	print("End")
main()