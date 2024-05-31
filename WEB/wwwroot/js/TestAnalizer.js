function getRandomInt(min, max) {
    min = Math.ceil(min);
    max = Math.floor(max);
    return Math.floor(Math.random() * (max - min + 1)) + min;
}

function func(a,name, b, c) {

    let q = c.length;
    let arr = [];
    let arr2 = [];
    for (let i = 0; i < q; i++) {
        
        arr.push(`rgba(${getRandomInt(1, 255)},${getRandomInt(1, 255)},${getRandomInt(1, 255)},0.2)`);
        arr2.push('rgba(0,0,0,1)');
    }

    const ctx = document.getElementById("donut-" + a).getContext('2d');
    const donut = new Chart(ctx, {
        type: 'doughnut',
        data: {
            labels: b,
            datasets: [{
                label: name,
                data: c,
                backgroundColor: arr,
                borderColor: arr2,
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
}

function func2(a, name, b, c) {

    let q = c.length;
    let arr = [];
    let arr2 = [];
    for (let i = 0; i < q; i++) {

        arr.push(`rgba(${getRandomInt(1, 255)},${getRandomInt(1, 255)},${getRandomInt(1, 255)},0.2)`);
        arr2.push('rgba(0,0,0,1)');
    }

    const ctx = document.getElementById("checkBox-" + a).getContext('2d');
    const donut = new Chart(ctx, {
        type: 'bar',
        data: {
            labels: b,
            datasets: [{
                label: name,
                data: c,
                backgroundColor: arr,
                borderColor: arr2,
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
}


function func4(a, name, b, c) {

    let q = c.length;
    let arr = [];
    let arr2 = [];
    for (let i = 0; i < q; i++) {

        arr.push(`rgba(${getRandomInt(1, 255)},${getRandomInt(1, 255)},${getRandomInt(1, 255)},0.2)`);
        arr2.push('rgba(0,0,0,1)');
    }
   

    const ctx = document.getElementById("donutSelect-" + a).getContext('2d');
    const donut = new Chart(ctx, {
        type: 'doughnut',
        data: {
            labels: b,
            datasets: [{
                label: name,
                data: c,
                backgroundColor: arr,
                borderColor: arr2,
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
}