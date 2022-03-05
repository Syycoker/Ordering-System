# Ordering System
This project consists of two applictions; TQSSandwichServer & TQSSandwichClient.

## Overview
The server establishes a connection to any and all clients looking to connect. The client attempts to establish a connnection to the server and if unsuccessful, it spawns a single thread and its sole purpose is to attempt to establish a connection to the server every 'x' seconds, if successful (connected) the thread is then disposed.

The client would then proceed to send an order via a delegate i created, the function passed to the delegate then creates an object and the object is the deserialised into a JSON string. The JSON string is then sent over to the server, if the server has successulyy recieved, serialised and aknowledged the order request, it sends an acknowledgement to the client saying "Order Confirmed". The order information is then displayed onto the server's form. If the client would like to remove the order,a similar operation is done and the server form ackowldges this message and updates its UI to reflect the action.

Once the time to order the items has come, the user behind the server will print the order request from all the clients into a .txt file onto a directory called "sanwhiches" and the file name reflects the date of the order. Unfortunately, I would have created a feature to order the items at a certain time through the place's website but they didn't have one, so for now it requres human interaction when it comes to ordering the items.
