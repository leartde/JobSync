import JobCardsColumn from '../components/JobCardsColumn';
import SearchBar from '../components/SearchBar';

const HomePage = () => {
    return (
        <div className='flex flex-col'>
            <SearchBar/>
            <div className="relative top-12 flex w-3/4 mx-auto ">
                <JobCardsColumn/>

            </div>
        </div>
    );
}

export default HomePage;
