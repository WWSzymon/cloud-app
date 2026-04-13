import React, { useEffect, useState } from 'react';

interface CloudTask {
    id: number;
    name: string;
    isCompleted: boolean;
}

const Dashboard: React.FC = () => {
    const [tasks, setTasks] = useState<CloudTask[]>([]);
    const [newTaskName, setNewTaskName] = useState('');
    const API_URL = "https://cloud-task-manager-api-v2-94570.azurewebsites.net/api/tasks";

    useEffect(() => { fetchTasks(); }, []);

    const fetchTasks = async () => {
        try {
            const response = await fetch(API_URL);
            const data = await response.json();
            setTasks(data);
        } catch (e) { console.error("Błąd pobierania", e); }
    };

    const addTask = async () => {
        if (!newTaskName) return;
        await fetch(API_URL, {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ name: newTaskName, isCompleted: false })
        });
        setNewTaskName('');
        fetchTasks();
    };

    // --- FUNKCJA ARTEFAKT 8.4: USUWANIE ---
    const handleDelete = async (id: number) => {
        await fetch(`${API_URL}/${id}`, { method: 'DELETE' });
        setTasks(tasks.filter(t => t.id !== id));
    };

    return (
        <div style={{ padding: '20px', textAlign: 'center' }}>
            {/* WYMUSZONY ZŁOTY NAPIS (Artefakt 8.3) */}
            <h1 style={{ color: 'gold' }}>☁️ Cloud App Dashboard</h1>
            
            <div style={{ marginBottom: '20px' }}>
                <input 
                    value={newTaskName}
                    onChange={(e) => setNewTaskName(e.target.value)}
                    placeholder="Wpisz nowe zadanie..."
                />
                <button onClick={addTask}>Dodaj Zadanie</button>
            </div>

            <div style={{ display: 'flex', flexDirection: 'column', alignItems: 'center' }}>
                {tasks.map(task => (
                    <div key={task.id} style={{ 
                        display: 'flex', justifyContent: 'space-between', 
                        width: '300px', border: '1px solid #ccc', margin: '5px', padding: '10px' 
                    }}>
                        <span>{task.name}</span>
                        <button 
                            onClick={() => handleDelete(task.id)}
                            style={{ backgroundColor: 'red', color: 'white', border: 'none', cursor: 'pointer' }}
                        >
                            Usuń
                        </button>
                    </div>
                ))}
            </div>
        </div>
    );
};

export default Dashboard;