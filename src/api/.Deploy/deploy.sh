# script_path=$(realpath "$0")
# echo "The script is located at: $script_path"
# pushd $script_path
pushd ..

sudo docker compose down
sudo docker system prune --force

git switch master
git pull
sudo docker compose up -d --build

popd