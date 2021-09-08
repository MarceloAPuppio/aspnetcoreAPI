export const setHeaderAuth = () => {
  let token = sessionStorage.getItem("token")
    ? sessionStorage.getItem("token")
    : localStorage.getItem("token");
  return `bearer ${token}`;
};

export const loadTable = (table, data) => {
  table.innerHTML = "";
  for (const element of data) {
    table.innerHTML += `<tr>
      <td class="column column-1"><img src="https://source.unsplash.com/random/50x50" alt="" class="table-nombre-img"><span class="table-nombre-nombre">${element.nombre}</span></td>
      <td class="column column-2">${element.id}</td>
      <td class="column column-3">${element.mail}</td>
      <td class="column column-4">${element.carrera}</td>
      <td class="column column-5">${element.otros}</td>
    </tr>`;
  }
};
