const $ = (element) => {
  return document.querySelector(element);
};

const form = $("#form");
const img = $("#imagen");

const post = async (formdata) => {
  let resp = await fetch("./Api/User", { method: "POST", body: formdata });
  console.log(resp);
  let obj = await resp.text();
  console.log(obj);
  return obj;
};

form.addEventListener("submit", async (e) => {
  e.preventDefault();
  img.src = await post(new FormData(form));
});
