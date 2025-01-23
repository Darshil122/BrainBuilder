// Timer functionality
const timerElement = document.getElementById('timer');
let timeLeft = 30; // 30 seconds

function updateTimer() {
    const minutes = Math.floor(timeLeft / 60);
    const seconds = timeLeft % 60;
    timerElement.textContent = `Time Left: ${minutes}:${seconds < 10 ? '0' : ''}${seconds}`;
    timeLeft--;

    if (timeLeft < 0) {
        clearInterval(timerInterval);
        alert("Time's up!");
    }
}

// Start the timer
const timerInterval = setInterval(updateTimer, 1000);



