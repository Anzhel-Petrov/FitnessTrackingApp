document.addEventListener('DOMContentLoaded', function () {
    const weeklyCanvas = document.getElementById('weeklyChart');
    if (weeklyCanvas) {
        const weeklyCtx = weeklyCanvas.getContext('2d');
        const weeklyChart = new Chart(weeklyCtx, {
            type: 'line',
            data: {
                labels: window.weeklyChartLabels,
                datasets: [{
                    label: 'Weight (kg)',
                    data: window.weeklyChartData,
                    borderColor: 'blue',
                    fill: false
                }]
            }
        });
    }

    const monthlyCanvas = document.getElementById('monthlyChart');
    if (monthlyCanvas) {
        const monthlyCtx = monthlyCanvas.getContext('2d');
        const monthlyChart = new Chart(monthlyCtx, {
            type: 'line',
            data: {
                labels: window.monthlyChartLabels,
                datasets: [{
                    label: 'Weight (kg)',
                    data: window.monthlyChartData,
                    borderColor: 'green',
                    fill: false
                }]
            }
        });
    }
});
