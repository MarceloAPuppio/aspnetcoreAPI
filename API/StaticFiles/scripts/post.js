export const setHeaderAuth = () => {
  let token = sessionStorage.getItem("Token")
    ? sessionStorage.getItem("Token")
    : localStorage.getItem("Token");
  return `${token}`;
};

export const loadTable = (table, data) => {
  table.innerHTML = "";
  for (const element of data) {
    table.innerHTML += `<tr>
      <td class="column column-1"><img src="https://source.unsplash.com/random/50x50" alt="" class="table-nombre-img"><span class="table-nombre-nombre">${element.Nombre}</span></td>
      <td class="column column-2">${element.ID}</td>
      <td class="column column-3">${element.Nombre}</td>
      <td class="column column-4">${element.Nombre}</td>
      <td class="column column-5">${element.Nombre}</td>
    </tr>`;
  }
};

export const loadRoles = (select, options) => {
  select.innerHTML = "";
  for (const option of options) {
    let optionHTML = document.createElement("option");
    optionHTML.classList.add("aside__Login__Option");
    optionHTML.innerHTML = option.Nombre;
    optionHTML.value = option.Nombre;
    select.appendChild(optionHTML);
  }
};
