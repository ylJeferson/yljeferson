import os
import sys
import time
from selenium import webdriver

hora = time.localtime().tm_hour
weekday = time.localtime().tm_wday

if 9 <= hora < 18 and weekday <= 5:
	ip = '192.168.11.1'
	response = os.system('ping -n 1 ' + ip + ' > NUL')
	if response == 1:
		options = webdriver.ChromeOptions()
		options.add_argument('--headless')
		driver = webdriver.Chrome(options=options)
		driver.get('http://administrador:N0v4ar@kazzobotucatu.duckdns.org:14000/vpn_summary.htm')
		driver.find_element_by_xpath('//input[@value="Disconnect"]').click()
		driver.quit()

	ip = '192.168.12.1'
	response = os.system('ping -n 1 ' + ip + ' > NUL')
	if response == 1:
		options = webdriver.ChromeOptions()
		options.add_argument('--headless')
		driver = webdriver.Chrome(options=options)
		driver.get('http://administrador:N0v4ar@doctbotucatu2.duckdns.org:14000/vpn_summary.htm')
		driver.find_element_by_xpath('//input[@value="Disconnect"]').click()
		driver.quit()

sys.exit()
quit()