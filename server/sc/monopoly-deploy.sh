set -x
ssh root@173.255.251.200 'cd frennzy; git pull'
ssh root@173.255.251.200 'pkill node'
ssh root@173.255.251.200 'cd frennzy/server && nohup /root/local/node/bin/node app.js > log/node.log ' &
