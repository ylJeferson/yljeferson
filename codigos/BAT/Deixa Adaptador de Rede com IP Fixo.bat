netsh interface ip set address name="Ethernet" static 192.168.0.206 255.255.255.0 192.168.0.1
netsh interface ip add address name="Ethernet" 20.0.0.206 255.255.255.0
netsh interface ip add address name="Ethernet" 192.168.195.206 255.255.255.0
netsh interface ip add address name="Ethernet" 192.168.196.206 255.255.255.0
netsh interface ip add address name="Ethernet" 192.168.197.206 255.255.255.0
netsh interface ip add address name="Ethernet" 192.168.198.206 255.255.255.0
netsh interface ip add address name="Ethernet" 192.168.199.206 255.255.255.0
netsh interface ip add address name="Ethernet" 192.168.200.206 255.255.255.0
netsh interface ip add address name="Ethernet" 192.168.201.206 255.255.255.0
netsh interface ip add address name="Ethernet" 192.168.202.206 255.255.255.0
netsh interface ip add address name="Ethernet" 192.168.203.206 255.255.255.0

netsh interface ip set dns name="Ethernet" static 192.168.0.1
netsh interface ip add dns name="Ethernet" 192.168.0.53 index=2