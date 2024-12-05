import JobCardsColumn from '../components/JobCardsColumn';
import JobPreview from '../components/JobPreview';
import SearchBar from '../components/SearchBar';

const HomePage = () => {
    return (
        <div className='flex flex-col'>
            <SearchBar/>
            <div className="mt-6 space-x-8 relative top-12 flex w-3/4 mx-auto  ">
                <JobCardsColumn/>
                <JobPreview/>

            </div>
        </div>
    );
}

export default HomePage;
