#!/bin/bash

# Navigate to the OAS directory
cd OAS

# Loop through each .yaml file in the current directory
for file in cds_*.yaml; do
  # Extract the client name by removing the 'cds_' prefix and '.yaml' suffix
  client_name=$(echo "$file" | sed 's/cds_\(.*\).yaml/\1/')
  
  # Capitalize the first letter of the client name
  client_name_capitalized="$(tr '[:lower:]' '[:upper:]' <<< ${client_name:0:1})${client_name:1}"

  # Use Kiota to generate the C# client
  kiota generate -l CSharp -c "Kiota${client_name_capitalized}Client" -n "Kiota${client_name_capitalized}.Client" -d "./$file" -o "../Clients/${client_name_capitalized}"
done

echo "C# clients have been generated in the Client directory."
