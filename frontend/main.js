window.addEventListener("DOMContentLoaded", (event) => {
    getVisitCount();
})

const functionApiUrl = 'https://getresumecounter-rsl2.azurewebsites.net/api/GetResumeCounter?code=prMAZCfQBkdn5yS0fWap9mVtgKkNRwo93fNnFnZyI_6gAzFuJ2_lew==';
const localFunctionApi = 'http://localhost:7071/api/GetResumeCounter';

const getVisitCount = () => {
    let count = 30; // some random number to get started
    fetch(functionApiUrl).then(response => {
        return response.json();
    }).then(response => {
        console.log("Website called function API.");
        count = response.count;
        document.getElementById("counter").innerText = count;
    }).catch(function(error) {
        console.log(error);
    })
    return count;
}