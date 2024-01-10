const API_KEY = "BcmNpKt1U6dvh1hyEHLyhFdHPmabwgDj";
function getWeather(location) {
    let url = `https://api.tomorrow.io/v4/weather/realtime?location=${location}&apikey=${API_KEY}`
    fetch(url).then((response) => {
        return response.json();
    }).then((data) => {
        console.log(data);
        let date = new Date(data.data.time);
        console.log("Time: ", date.toLocaleString());
        console.log("Temperature: ", data.data.values.temperature);

        document.getElementById("data-temperature").textContent = data.data.values.temperature;
        document.getElementById("data-time").textContent = date.toLocaleString();
    });
}
document.addEventListener("DOMContentLoaded", () => {
    document.getElementById("btn-search").addEventListener("click", () => {
        getWeather(document.getElementById("input-city").value);
    })
});