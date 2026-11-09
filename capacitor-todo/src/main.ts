import './style.css'
import { loadTodos, saveTodos } from './todos'
import type { Todo } from './todos'

let todos: Todo[] = loadTodos()

const app = document.querySelector('#app')!
app.innerHTML = `
  <main>
    <h1>Mis Tareas</h1>
    <p id="counter"></p>
    <div id="empty">
      <h3>No tienes tareas todavía</h3>
      <p>Añade tu primera tarea abajo</p>
    </div>
    <ul id="list"></ul>
    <form id="form">
      <input id="title" placeholder="Título de la tarea" required>
      <textarea id="desc" placeholder="Descripción (opcional)"></textarea>
      <button type="submit">+ Añadir Tarea</button>
      <button type="button" id="clear">Borrar completadas</button>
    </form>
  </main>
`

const list = document.querySelector('#list')! as HTMLUListElement
const counter = document.querySelector('#counter')! as HTMLParagraphElement
const empty = document.querySelector('#empty')! as HTMLDivElement

function render() {
    list.innerHTML = ''
    todos.forEach(t => {
        const li = document.createElement('li')
        li.className = t.done ? 'done' : ''
        li.innerHTML = `
      <input type="checkbox" ${t.done ? 'checked' : ''} data-id="${t.id}">
      <div class="txt"><b>${t.title}</b><small>${t.description || ''}</small></div>
      <button data-del="${t.id}">🗑</button>
    `
        list.appendChild(li)
    })
    const pending = todos.filter(t => !t.done).length
    const done = todos.length - pending
    counter.textContent = `${pending} pendientes · ${done} completadas`
    empty.style.display = todos.length ? 'none' : 'block'
    saveTodos(todos)
}

document.querySelector('#form')!.addEventListener('submit', e => {
    e.preventDefault()
    const title = (document.querySelector('#title') as HTMLInputElement).value.trim()
    const desc = (document.querySelector('#desc') as HTMLTextAreaElement).value.trim()
    if (!title) return
    todos.unshift({ id: Date.now(), title, description: desc, done: false })
    render()
        ; (document.querySelector('#title') as HTMLInputElement).value = ''
        ; (document.querySelector('#desc') as HTMLTextAreaElement).value = ''
})

list.addEventListener('change', e => {
    const cb = e.target as HTMLInputElement
    todos = todos.map(t => t.id == Number(cb.dataset.id) ? { ...t, done: cb.checked } : t)
    render()
})

list.addEventListener('click', e => {
    const btn = (e.target as HTMLElement).closest('[data-del]') as HTMLElement | null
    if (!btn) return
    todos = todos.filter(t => t.id != Number(btn.dataset.del))
    render()
})

document.querySelector('#clear')!.addEventListener('click', () => {
    todos = todos.filter(t => !t.done)
    render()
})

render()