const BASE_URL = "http://localhost:5102/api/productos";

const tbody = document.querySelector("#tabla tbody");
const form = document.getElementById("formProducto");

async function listar() {
    const resp = await fetch(BASE_URL);
    const data = await resp.json();
    tbody.innerHTML = "";
    data.forEach(p => {
        const tr = document.createElement("tr");
        tr.innerHTML = `
      <td>${p.id}</td>
      <td>${p.nombre}</td>
      <td>${p.descripcion ?? ""}</td>
      <td>${p.precio}</td>
      <td class="row-actions">
        <button onclick="editar(${p.id})">Editar</button>
        <button onclick="eliminar(${p.id})">Eliminar</button>
      </td>
    `;
        tbody.appendChild(tr);
    });
}

async function editar(id) {
    const resp = await fetch(`${BASE_URL}/${id}`);
    if (!resp.ok) return alert("No encontrado");
    const p = await resp.json();
    document.getElementById("id").value = p.id;
    document.getElementById("nombre").value = p.nombre;
    document.getElementById("descripcion").value = p.descripcion ?? "";
    document.getElementById("precio").value = p.precio;
}

async function eliminar(id) {
    if (!confirm("¿Eliminar producto?")) return;
    const resp = await fetch(`${BASE_URL}/${id}`, { method: "DELETE" });
    if (resp.status === 204) await listar();
    else alert("No se pudo eliminar");
}

form.addEventListener("submit", async (e) => {
    e.preventDefault();
    const id = document.getElementById("id").value;
    const payload = {
        id: id ? parseInt(id) : 0,
        nombre: document.getElementById("nombre").value,
        descripcion: document.getElementById("descripcion").value,
        precio: parseFloat(document.getElementById("precio").value)
    };

    let resp;
    if (id) {
        resp = await fetch(`${BASE_URL}/${id}`, {
            method: "PUT",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(payload)
        });
        if (resp.status === 204) {
            form.reset();
            await listar();
        } else {
            const err = await resp.json();
            alert(err.error ?? "Error al actualizar");
        }
    } else {
        resp = await fetch(BASE_URL, {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(payload)
        });
        if (resp.status === 201) {
            form.reset();
            await listar();
        } else {
            const err = await resp.json();
            alert(err.error ?? "Error al crear");
        }
    }
});

listar();
