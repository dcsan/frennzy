# set -x

# this will add all files in the directory
# including any junk you have in progress, temp files etc.
git add .

# always pull before you push to sync with upstream
# git doesnt do this for you ^^
git pull heroku master

# check theres a comment!
if [ -z "$1" ]; then
    echo "

HEY!!! please enter a comment! like:
   sc/commit-push 'added anti-gravity feature'

warning: didn't add your work to git without comment"
    exit
fi

# push your work to the named repo
git push heroku master
