
const url = "https://localhost:7190/posthub"
const connection = new signalR.HubConnectionBuilder()
    .withUrl(url)
    .configureLogging(signalR.LogLevel.Information)
    .build();

function getPosts() {
    $.ajax({
        url: "https://localhost:7190/Home",
        type: "GET",
        success: function (data) {
            console.log(data);
            //$("#posts").empty();
            //$.each(data, function (index, value) {
            //    $("#posts").append("<div class='post'>" + value.title + "</div>");
            //});
        },
        error: function (error) {
            console.log(`Error ${error}`);
        }
    });
}

connection.on("ReceivePost", () => {
    getPosts();
});

async function start() {
    try {
        await connection.start();
        console.log("SignalR Connected.");
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
};

connection.onclose(async () => {
    await start();
});


// Start the connection.
start();


