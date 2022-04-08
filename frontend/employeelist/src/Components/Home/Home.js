import React from 'react'
import { useEffect, useState } from 'react'

const Home = () => {
    const baseurl = "http://localhost:41105/api/"
    const [employeeData, setEmployeeData] = useState([])
    const [selectedID, setSelectedID] = useState(null)
    
    useEffect(() => {
        getEmployees()
        
        console.log('i am running')
    }, [])
    
    const getEmployees = () => {
        fetch(baseurl+'Employee', {
            method: 'GET',
            headers: {
                'Content-Type': 'application/json'
            }
        })
        .then(async res => {
            try {
                const data = await res.json()
                setEmployeeData(data)
            } catch (error) {
                console.log('error occured in getEmployees', error)
            }
        })
    }

    const deleteEmployee = (deleteId) => {
        console.log('I was clicked')
        setEmployeeData(employeeData.filter((id) => id.EmployeeId !== deleteId))
        fetch(baseurl+'Employee/'+ deleteId, {
            method: 'DELETE',
            headers: {
                'Content-Type': 'application/json'
            }
        })
        .then(async res => {
            try {
                const data = await res.json()
            } catch (error) {
                console.log('there was an error ',error)
            }
        })
    }
    
    return (
    <div className='bg-blue-100'>Home
    <table className='table-auto border-2 rounded bg-lime-100 mt-5 mx-auto'>
        <thead className='pr-2'>
            <tr>
               <th>Employee ID</th>
                <th>Employee Name</th> 
            </tr>
        </thead>
        <tbody>
            {employeeData && 
                employeeData.map((id) => (
                    
                    <tr key={id._id}>
                        <td onClick={() => deleteEmployee(id.EmployeeId)}>
                            {id.EmployeeId}
                        </td>
                        <td>
                            {id.EmployeeName}
                        </td>
                    </tr>
                    
                    
                ))
            }
        </tbody>
    </table>
    </div>
  )
}

export default Home