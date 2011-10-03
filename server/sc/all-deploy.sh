git add .
git pull heroku master
if [ -z "$1" ]; then
    echo "please enter a comment!"
    exit
fi

git commit -a -m $1
sc/deploy.sh
