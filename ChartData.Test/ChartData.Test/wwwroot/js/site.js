// Fetch chart data from API
fetch('/api/ChartData')
    .then(response => {
        if (!response.ok) {
            throw new Error('Network response was not ok');
        }
        return response.json();
    })
    .then(chartData => {
        console.log(chartData); // Check the fetched data

        if (chartData && chartData.length > 0) {
            const labels = chartData.map(data => `Month ${data.Month}`);
            const values = chartData.map(data => data.Value);

            const ctx = document.getElementById('cryptoChart').getContext('2d');
            const myChart = new Chart(ctx, {
                type: 'line',
                data: {
                    labels: labels,
                    datasets: [{
                        label: 'Crypto Value',
                        data: values,
                        borderColor: 'rgba(75, 192, 192, 1)',
                        backgroundColor: 'rgba(75, 192, 192, 0.2)',
                        borderWidth: 1
                    }]
                },
                options: {
                    scales: {
                        y: {
                            beginAtZero: true
                        }
                    }
                }
            });
        } else {
            console.error("No data available for chart rendering.");
        }
    })
    .catch(error => console.error('Error fetching chart data:', error));