document.addEventListener('DOMContentLoaded', function () {
    const ctx = document.getElementById('progressChart').getContext('2d');
    if (weekNumbers && averageWeights && goalWeight)
    {
        new Chart(ctx,
        {
            type: 'line',
            data:
            {
                labels: weekNumbers,
                datasets: [{
                    label: 'Average Weight (kg)',
                    data: averageWeights,
                    borderColor: 'rgba(75, 192, 192, 1)',
                    backgroundColor: 'rgba(75, 192, 192, 0.2)',
                    borderWidth: 2,
                    pointRadius: 5,
                    pointBackgroundColor: 'white',
                    pointBorderColor: 'rgba(75, 192, 192, 1)',
                    tension: 0.4
                }]
            },
            options:
            {
                responsive: true,
                plugins: {
                    legend: { display: true, position: 'top' },
                    tooltip: { enabled: true }
                },
                scales: {
                    x: {
                        title: { display: true, text: 'Week Number' }
                    },
                    y: {
                        title: { display: true, text: 'Weight (kg)' },
                        beginAtZero: false,
                        suggestedMin: goalWeight
                    }
                }
            }
        });
    }
});