import React, {useEffect, useState} from 'react';
import { API } from 'aws-amplify'
import { withAuthenticator } from 'aws-amplify-react'

import './App.css';

function App() {

  /*************
 * EXAMPLE calling an unathenticated endpoint
  
  // use state basically gives a state object with an updateState function
  const [people, updatePeople] = useState([]); 

  async function callPeopleApi(){
    try {
      const peopleData = await API.get('slsappapi', '/people');
      console.log('people data: ', peopleData);
      updatePeople(peopleData.people);
    } catch (err) { console.log({ err }) }
  }

  useEffect(()=>{ // useEffect ensures passed function will be called prior any painting on screen
    callPeopleApi();
  }, []); // passing an empty array will make the effect function invoked only once

  ********/
  /*************
 * EXAMPLE calling an athenticated endpoint
 const [coins, updateCoins] = useState([]); 
 async function callCoinsApi(){
  try {
    const coinsData = await API.get('slsappapi', '/coins');
    console.log('coins data: ', coinsData);
    // updateCoins(coinsData.people);
  } catch (err) { console.log({ err }) }
}
useEffect(()=>{ // useEffect ensures passed function will be called prior any painting on screen
  callCoinsApi();
}, []); // passing an empty array will make the effect function invoked only once
*/

const [searchString, updateSearchString] = useState([]);
const [searchData, updateSearchData] = useState([]);
async function searchJobs(){
  try{
    const data = await API.post('slsappapi', '/jobs', { body: { search: searchString } });
    updateSearchData(data.jobs);
    console.log('search data: ', data);
  } catch (err) { console.log({ err }) }
}

function createMarkup(markup) {
  return {__html: markup};
}

  return (
    <div className="App">
      <h1>Hi</h1>
      <input onChange={e => updateSearchString(e.target.value)} />
      <button onClick={searchJobs}>Search Jobs</button>

      {
        searchData.map((job,i) => 
        <div key={i}>
          <h1>{job.company}</h1>
          <h2>{job.type}</h2>
          <div dangerouslySetInnerHTML={createMarkup(job.description)}></div>
        </div>
          )
      } 

      {/* {
        // people.map((person,i) => <h2>{person.name}</h2>)
        coins.map((coin,i) => <h2>{coin}</h2>)
      } */}
    </div>
  );
}

// export default App;
export default withAuthenticator(App); // adding the aws-amplify-react auth component
