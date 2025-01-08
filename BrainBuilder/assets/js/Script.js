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

// Questions Data
const questions = [
    {
        title: "Question 1",
        text: "The arithmetic mean of the 5 consecutive integers starting with 's' is 'a'. What is the arithmetic mean of 9 consecutive integers that start with s + 2?",
        options: ["78", "58", "68", "98"],
    },
    {
        title: "Question 2",
        text: "What is the sum of the first 10 positive integers?",
        options: ["45", "55", "65", "75"],
    },
    {
        title: "Question 3",
        text: "Solve: 12 * 12 - 6 * 6?",
        options: ["36", "72", "144", "108"],
    },
];

// Current Question Index
let currentQuestionIndex = 0;

// DOM Elements
const questionTitle = document.getElementById("question-title");
const questionText = document.getElementById("question-text");
const optionsSection = document.getElementById("options-section");
const nextButton = document.getElementById("next-button");

// Load Question Function
function loadQuestion(index) {
    if (index >= questions.length) {
        alert("You've completed all the questions!");
        nextButton.disabled = true; // Disable the button after the last question
        return;
    }

    const question = questions[index];

    // Update question title and text
    questionTitle.textContent = question.title;
    questionText.textContent = question.text;

    // Update options
    optionsSection.innerHTML = ""; // Clear previous options
    question.options.forEach((option, i) => {
        optionsSection.innerHTML += `
            <div class="form-check mb-3">
                <input class="form-check-input" type="radio" name="answer" id="option${i + 1}" value="${option}">
                <label class="form-check-label" for="option${i + 1}">${String.fromCharCode(65 + i)}. ${option}</label>
            </div>
        `;
    });
}

// Next Button Click Event
nextButton.addEventListener("click", () => {
    currentQuestionIndex++; // Move to the next question
    loadQuestion(currentQuestionIndex);
});

// Load the first question on page load
loadQuestion(currentQuestionIndex);



