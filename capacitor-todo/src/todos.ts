export interface Todo { id: number; title: string; description: string; done: boolean }
const KEY = 'todos'
export const loadTodos = (): Todo[] => {
    try { return JSON.parse(localStorage.getItem(KEY) || '[]') } catch { return [] }
}
export const saveTodos = (t: Todo[]) => localStorage.setItem(KEY, JSON.stringify(t))