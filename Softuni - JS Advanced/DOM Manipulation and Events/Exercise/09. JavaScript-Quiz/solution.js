function solve() {
  function displayResults(correctCount, totalQuestions, heading, results) {
    if (correctCount === totalQuestions) {
      heading.textContent = 'You are recognized as top JavaScript fan!';
    } else {
      heading.textContent = `You have ${correctCount} right answers`;
    }
    results.style.display = 'block';
  }

  const quiz = document.getElementById('quizzie');
  const sections = Array.from(quiz.getElementsByTagName('section'));
  const correctAnswers = [
    'onclick',
    'JSON.stringify()',
    'A programming API for HTML and XML documents'
  ];

  let correctAnswersCount = 0;

  const results = document.getElementById('results');
  const heading = results.querySelector('h1');

  sections.forEach((section, index) => {
    const answers = section.querySelectorAll('li');

    answers.forEach(answer => {
      answer.addEventListener('click', () => {
        const selectedAnswer = answer.querySelector('p').textContent;

        if (selectedAnswer === correctAnswers[index]) {
          correctAnswersCount++;
        }

        section.style.display = 'none';

        if (index < sections.length - 1) {
          sections[index + 1].style.display = 'block';
        } else {
          displayResults(correctAnswersCount, correctAnswers.length, heading, results);
        }
      });
    });
  });
}