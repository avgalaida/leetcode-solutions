import {useState, useEffect} from 'react';
import './App.css'; // Подключаем минимальные стили

// URL к репозиторию с решениями
const REPO_URL = 'https://raw.githubusercontent.com/avgalaida/leetcode-solutions/main/Problems';

const App = () => {
    const [solutions, setSolutions] = useState([]);
    const [currentPage, setCurrentPage] = useState(1);
    const [filter, setFilter] = useState({
        difficulty: '', tags: '', title: ''
    });

    const solutionsPerPage = 5;

    useEffect(() => {
        const fetchSolutions = async () => {
            try {
                const response = await fetch(`${REPO_URL}/metadata.json`);
                const data = await response.json();
                setSolutions(data.reverse()); // Решения сортируются по времени добавления (сначала последние)
            } catch (error) {
                console.error('Ошибка при загрузке решений:', error);
            }
        };

        fetchSolutions();
    }, []);

    // Фильтрация решений
    const filteredSolutions = solutions.filter(solution => (filter.difficulty ? solution.difficulty === filter.difficulty : true) && (filter.tags ? solution.tags.includes(filter.tags) : true) && (filter.title ? solution.title.toLowerCase().includes(filter.title.toLowerCase()) : true));

    // Пагинация
    const indexOfLastSolution = currentPage * solutionsPerPage;
    const indexOfFirstSolution = indexOfLastSolution - solutionsPerPage;
    const currentSolutions = filteredSolutions.slice(indexOfFirstSolution, indexOfLastSolution);

    const totalPages = Math.ceil(filteredSolutions.length / solutionsPerPage);

    const nextPage = () => {
        if (currentPage < totalPages) {
            setCurrentPage(currentPage + 1);
        }
    };

    const prevPage = () => {
        if (currentPage > 1) {
            setCurrentPage(currentPage - 1);
        }
    };

    return (<div className="App">
        <h1>LeetCode Solutions</h1>

        {/* Фильтры */}
        <div className="filters">
            <input
                type="text"
                placeholder="Поиск по названию"
                value={filter.title}
                onChange={e => setFilter({...filter, title: e.target.value})}
            />
            <select onChange={e => setFilter({...filter, difficulty: e.target.value})}>
                <option value="">Все уровни сложности</option>
                <option value="easy">Easy</option>
                <option value="medium">Medium</option>
                <option value="hard">Hard</option>
            </select>
            <input
                type="text"
                placeholder="Поиск по тегам"
                value={filter.tags}
                onChange={e => setFilter({...filter, tags: e.target.value})}
            />
        </div>

        <ul className="solutions-list">
            {currentSolutions.map((solution, index) => (<li key={index} className="solution-item">
                <h2>{solution.title}</h2>
                <p>Difficulty: {solution.difficulty}</p>
                <p>Tags: {solution.tags.join(', ')}</p> {/* Отображение тегов */}
                <p>{solution.description}</p>
                <a
                    href={solution.leetcode_url}
                    target="_blank"
                    rel="noopener noreferrer"
                >
                    Задача на LeetCode
                </a>
                <ul className="solutions-variants">
                    {solution.solutions.map((sol, solIndex) => (<li key={solIndex}>
                        <p>{sol.description}</p>
                        <a
                            href={`https://github.com/avgalaida/leetcode-solutions/blob/main/Problems/${encodeURIComponent(sol.file)}`}
                            target="_blank"
                            rel="noopener noreferrer"
                        >
                            Решение
                        </a>
                    </li>))}
                </ul>
            </li>))}
        </ul>

        {/* Пагинация */}
        <div className="pagination">
            <button onClick={prevPage} disabled={currentPage === 1}>
                Предыдущая
            </button>
            <span>{currentPage} из {totalPages}</span>
            <button onClick={nextPage} disabled={currentPage === totalPages}>
                Следующая
            </button>
        </div>
    </div>);
};

export default App;