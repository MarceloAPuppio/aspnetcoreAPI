import { setHeaderAuth, loadTable } from "./post.js";
localStorage.setItem("token", "asasassdssdsdsd");
console.log(setHeaderAuth());

const data = [
  {
    nombre: "pepe",
    id: "12",
    mail: "mail.com",
    carrera: "Economía",
    otros: "otros",
  },
  {
    nombre: "Josecito",
    id: "15",
    mail: "mail.com",
    carrera: "Economía",
    otros: "otros",
  },
  {
    nombre: "Chopper",
    id: "1",
    mail: "mail.com",
    carrera: "Economía",
    otros: "otros",
  },
  {
    nombre: "Chopper",
    id: "1",
    mail: "mail.com",
    carrera: "Economía",
    otros: "otros",
  },
  {
    nombre: "Chopper",
    id: "1",
    mail: "mail.com",
    carrera: "Economía",
    otros: "otros",
  },
  {
    nombre: "Chopper",
    id: "1",
    mail: "mail.com",
    carrera: "Economía",
    otros: "otros",
  },
  {
    nombre: "Chopper",
    id: "1",
    mail: "mail.com",
    carrera: "Economía",
    otros: "otros",
  },
];
loadTable(document.getElementById("tBody"), data);
// const $ = (element) => {
//   return document.querySelector(element);
// };

// const form = $("#form");
// const img = $("#imagen");

// const post = async (formdata) => {
//   let resp = await fetch("./Api/User", { method: "POST", body: formdata });
//   console.log(resp);
//   let obj = await resp.text();
//   console.log(obj);
//   return obj;
// };

// form.addEventListener("submit", async (e) => {
//   e.preventDefault();
//   img.src = await post(new FormData(form));
// });
