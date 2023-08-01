const form = document.getElementById("form")
const email = document.getElementById("email")
const password = document.getElementById("password")
const iconSubmit = document.getElementById("icon")
const iconSubmit2 = document.getElementById("icon2")

form.addEventListener("submit", (e) => {
  e.preventDefault()
  checkInputs()
})

function checkInputs() {
  const emailValue = email.value
  const passwordValue = password.value

  if (emailValue === "") {
    setErrorForE(email, "Preencha seu email")
  } else if (!checkEmail(emailValue)) {
    setErrorForE(email, "Digite um email válido")
  } else {
    setSuccessForE(email)
  }
  if (passwordValue === "") {
    setErrorForP(password, "Digite sua senha")
  } else {
    setSuccessForP(password)
  }
}

function setSuccessForP(input) {
  const formControl = input.parentElement

  formControl.className = "form-control success"
  iconSubmit.className = "fa-solid fa-circle-check"
}
function setSuccessForE(input) {
  const formControl = input.parentElement

  formControl.className = "form-control success"
  iconSubmit2.className = "fa-solid fa-circle-check"
}
function setErrorForP(input, message) {
  const formControl = input.parentElement
  const small = formControl.querySelector("small")

  small.innerText = message
  iconSubmit.className = "fa-solid fa-circle-xmark"
  formControl.className = "form-control error"
}
function setErrorForE(input, message) {
  const formControl = input.parentElement
  const small = formControl.querySelector("small")

  small.innerText = message
  iconSubmit2.className = "fa-solid fa-circle-xmark"
  formControl.className = "form-control error"
}
function checkEmail(email) {
  return /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/.test(
    email
  )
}

function eyeClick() {
  let inputTypeIsPassword = password.type == "password"

  if (inputTypeIsPassword == true) {
    showPassword()
  } else {
    hidePassword()
  }
}

function showPassword() {
  password.setAttribute("type", "text")
}

function hidePassword() {
  password.setAttribute("type", "password")
}