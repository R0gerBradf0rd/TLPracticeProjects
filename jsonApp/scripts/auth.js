import { elements } from "./dom.js";

function loginSuccess(login) {
  elements.usernameSpan.textContent = login;
  elements.loginButton.style.display = 'none';
  elements.userGreeting.style.display = 'flex';
  elements.startButton.style.display = 'block';
}

function handleLogout() {
  localStorage.removeItem('currentUser');
  elements.loginButton.style.display = 'block';
  elements.welcomeSection.style.display = 'block';
  elements.userGreeting.style.display = 'none';
  elements.startButton.style.display = 'none';               
  elements.jsonSection.style.display = 'none';        
}

export function initAuth() {
  const savedUser = localStorage.getItem('currentUser');
  if (savedUser) loginSuccess(savedUser);

  elements.loginButton.addEventListener('click', () => {
    elements.loginForm.style.display = 'block';
  });

  elements.loginFormButton.addEventListener('click', () => {
    const login = elements.userLogin.value;

    if (!login) {
      elements.loginError.style.display = 'block';
      return; 
    }

    elements.loginError.style.display = 'none';

    localStorage.setItem('currentUser', login);
    loginSuccess(login);
    elements.loginForm.style.display = 'none';
  });

  elements.logoutButton.addEventListener('click', handleLogout);
}

elements.startButton.addEventListener('click', () => {
    elements.startButton.style.display = 'none';
    elements.welcomeSection.style.display = 'none'
})