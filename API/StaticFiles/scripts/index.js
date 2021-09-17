﻿import { setHeaderAuth, loadTable, loadRoles } from "./post.js";
// localStorage.setItem("token", "asasassdssdsdsd");
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
document.getElementById("logged-roles").addEventListener("change", (e) => {
  console.log(e.target.value);
}),
  //CARGAMOS ROLES
  loadRoles(
    document.getElementById("logged-roles"),
    JSON.parse(sessionStorage.getItem("Data")).Roles
  );
//CARGAMOS LA TABLA... MIENTRAS CARGA, ESTÁ EL SPINNER ACTIVADO
fetch("./api/user", {
  headers: {
    authorization: setHeaderAuth(),
  },
})
  .then((res) => {
    return res.json();
  })
  .then((res) => {
    console.log(res);
    document.querySelector(".spinner").style.display = "none";
    document.querySelector(".database-table").style.display = "block";
    loadTable(document.getElementById("tBody"), res);
  });

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
