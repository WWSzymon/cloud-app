import { useState } from 'react'

function App() {
  const [count, setCount] = useState(0)

  return (
    <div style={{ textAlign: 'center', marginTop: '60px', fontFamily: 'sans-serif' }}>
      <div>
        <a href="https://vitejs.dev" target="_blank">
          <img src="https://upload.wikimedia.org/wikipedia/commons/f/f1/Vitejs-logo.svg" style={{ height: '8em', padding: '1.5em' }} alt="Vite logo" />
        </a>
        <a href="https://react.dev" target="_blank">
          <img src="https://upload.wikimedia.org/wikipedia/commons/a/a7/React-icon.svg" style={{ height: '8em', padding: '1.5em' }} alt="React logo" />
        </a>
      </div>
      <h1 style={{ fontSize: '3.2em', fontWeight: 'bold' }}>Vite + React</h1>
      <div style={{ padding: '2em' }}>
        <button 
          onClick={() => setCount((count) => count + 1)}
          style={{ padding: '10px 20px', fontSize: '1.2em', cursor: 'pointer', borderRadius: '8px', border: '1px solid #ccc' }}
        >
          count is {count}
        </button>
        <p style={{ marginTop: '20px', color: '#888' }}>
          Edit <code>src/App.tsx</code> and save to test HMR
        </p>
      </div>
    </div>
  )
}

export default App