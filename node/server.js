//npm install socket.io
serverSocket = require("socket.io")(3000);

console.log("ServerSocket startup on port", 3000);

// Starts the server to listen new connections
serverSocket.on("connection", function (socket) {
    console.log("A new client Id:", socket.id, " has connected!");
    
    socket.on("client_message",(data)=>{
            console.log("Client:" + data);
            serverSocket.sockets.emit("response_server","Server:The connection is Ok");
    });
});
