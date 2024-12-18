// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
var weeklyCtx = document.getElementById('weeklyChart').getContext('2d');
var weeklyChart = new Chart(weeklyCtx, {
    type: 'line',
    data: {
        labels: @Html.Raw(Json.Serialize(Model.WeeklyRecords.Select(r => r.DateLogged.ToShortDateString()))),
        datasets: [{
            label: 'Weight (kg)',
            data: @Html.Raw(Json.Serialize(Model.WeeklyRecords.Select(r => r.CurrentWeight))),
            borderColor: 'blue',
            fill: false
        }]
    }
});

var monthlyCtx = document.getElementById('monthlyChart').getContext('2d');
var monthlyChart = new Chart(monthlyCtx, {
    type: 'line',
    data: {
        labels: @Html.Raw(Json.Serialize(Model.MonthlyRecords.Select(r => r.DateLogged.ToShortDateString()))),
        datasets: [{
            label: 'Weight (kg)',
            data: @Html.Raw(Json.Serialize(Model.MonthlyRecords.Select(r => r.CurrentWeight))),
            borderColor: 'green',
            fill: false
        }]
    }
});