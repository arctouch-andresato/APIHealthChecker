# APIHealthChecker
App to check if the API end points are responding. 

## External libs:
 - Prism
 - Newtonsoft.Json
 
 ## How to include an api to be tested:
  - Add the api details in the AppList.json file inside the Data folder in the shared project.
  - Create a file with the name defined in this json file
  - Add the urls of the endpoints in this newly created file
  - Set the file as embeded resource
  - Generate a new build and install it on the device.
