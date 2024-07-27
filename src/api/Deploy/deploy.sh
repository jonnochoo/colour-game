$SERVICE_NAME=myapi
$APP_DLL=api.dll
$WORK_DIR=/home/jonno/Dev/colour-game/src/api/bin/Release/net8.0/publish
# check if service is active
IS_ACTIVE=$(sudo systemctl is-active $SERVICE_NAME)
if [ "$IS_ACTIVE" == "active" ]; then
    # restart the service
    echo "Service is running"
    echo "Restarting service"
    sudo systemctl restart $SERVICE_NAME
    echo "Service restarted"
else
    # create service file
    echo "Creating service file"
    sudo cat > /etc/systemd/system/${SERVICE_NAME//'"'/}.service << EOF
[Unit]
Description=My API
After=network.target

[Service]
WorkingDirectory=$WORK_DIR
ExecStart=/usr/bin/dotnet $WORK_DIR/$APP_DLL
Restart=always
RestartSec=10
KillSignal=SIGINT
SyslogIdentifier=$SERVICE_NAME
Environment=ASPNETCORE_ENVIRONMENT=Production
Environment=DOTNET_PRINT_TELEMETRY_MESSAGE=false

[Install]
WantedBy=multi-user.target

EOF
    # restart daemon, enable and start service
    echo "Reloading daemon and enabling service"
    sudo systemctl daemon-reload 
    sudo systemctl enable ${SERVICE_NAME//'.service'/} # remove the extension
    sudo systemctl start ${SERVICE_NAME//'.service'/}
    echo "Service Started"
fi

exit 0