#!/bin/bash

GDVERSION="3.5"

GODOTDIR="$HOME/.godot"

# DOWNLOAD GODOT

download() {
    mkdir -p $GODOTDIR/godot/$GDVERSION
    rm -rf $GODOTDIR/godot/$GDVERSION/*
    curl https://downloads.tuxfamily.org/godotengine/$GDVERSION/mono/Godot_v$GDVERSION-stable_mono_x11_64.zip --output $GODOTDIR/godot/$GDVERSION/godot_v$GDVERSION.zip
    unzip -o $GODOTDIR/godot/$GDVERSION/godot_v$GDVERSION.zip -d $GODOTDIR/godot/$GDVERSION/
}

FILE=$GODOTDIR/godot/$GDVERSION/Godot_v$GDVERSION-stable_mono_x11_64
if [ ! -d "$FILE" ]; then
    echo "[!]Version of godot not found, starting download..."
    download
fi

nohup $GODOTDIR/godot/$GDVERSION/Godot_v$GDVERSION-stable_mono_x11_64/Godot_v$GDVERSION-stable_mono_x11.64 -e &
