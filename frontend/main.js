window.addEventListener("DOMContentLoaded", (event) => {
    getVisitCount();
})

const functionApiUrl = 'https://getresumecounter-rsl.azurewebsites.net/api/GetResumeCounter?code=_bnMDzPA2K_JUKxk3iUiSu-DJNCN_Qngkw4DbRWOy5y5AzFuKq-0FQ==';
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