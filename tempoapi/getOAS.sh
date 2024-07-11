#!/bin/bash

# Define the directory where you want to save the files.
download_directory="OAS"

# Create the directory if it doesn't exist.
if [ ! -d "$download_directory" ]; then
    mkdir -p "$download_directory"
fi

# Make sure the 'api_urls' file exists and can be read.
if [ ! -f api_urls ]; then
    echo "Error: 'api_urls' file not found."
    exit 1
fi

# Read each URL from the 'api_urls' file and download the file using 'wget'.
while IFS= read -r url; do
    echo "Downloading $url..."
    wget -P "$download_directory" "$url"
done < api_urls

echo "Download completed. Files are saved in the '$download_directory' directory."
