import React, { useState, useEffect } from "react";
import { Card } from "primereact/card";
import { useNavigate } from "react-router-dom";
import axios from "axios";
import { keycloak } from "../../keycloak";

const CourseCard = ({ course, fetchCourses }) => {
  const DropCourseToStudent = async () => {
    try {
      const token = keycloak.token;
      await axios.get(
        `https://localhost:7025/enrolled-course/drop-course/${course.id}`,
        {
          headers: {
            Authorization: `Bearer ${token}`,
          },
        }
      );
      fetchCourses(); // Refresh courses after dropping a course
    } catch (error) {
      console.error("Error dropping course:", error);
    }
  };

  return (
    <div key={course.id} className="course-card">
      <img src={course.imageUrl} alt={course.title} className="course-image" />
      <h3 className="course-name">{course.title}</h3>
      <p className="course-price">Price: ${course.price}</p>
      <button onClick={DropCourseToStudent} className="button">
        Drop Course
      </button>
    </div>
  );
};

const StudentEnrolledCourses = () => {
  const [courses, setCourses] = useState([]);
  const [searchTerm, setSearchTerm] = useState("");
  const [loading, setLoading] = useState(true);
  const navigate = useNavigate();

  const fetchCourses = async () => {
    try {
      const token = keycloak.token;
      const response = await axios.get(
        "https://localhost:7025/enrolled-course/get-courses",
        {
          headers: {
            Authorization: `Bearer ${token}`,
          },
        }
      );
      setCourses(response.data || []); // Ensure response data is set as an array
      setLoading(false);
    } catch (error) {
      console.error("Error fetching courses:", error);
      setLoading(false);
    }
  };

  useEffect(() => {
    fetchCourses();
  }, []);

  const filteredCourses = courses.filter((course) =>
    course.title.toLowerCase().includes(searchTerm.toLowerCase())
  );

  return (
    <Card title="SMART ED" className="custom-card">
      <div className="search-container">
        <input
          type="text"
          placeholder="Search courses..."
          value={searchTerm}
          onChange={(e) => setSearchTerm(e.target.value)}
          className="search-input"
        />
      </div>

      <div className="courses-list">
        {loading ? (
          <p>Loading courses...</p>
        ) : (
          filteredCourses.map((course) => (
            <CourseCard
              key={course.id}
              course={course}
              fetchCourses={fetchCourses} // Pass fetchCourses as a prop
            />
          ))
        )}
      </div>
    </Card>
  );
};

export default StudentEnrolledCourses;



// import React, { useState, useEffect } from "react";
// import { Card } from "primereact/card";
// import { useNavigate } from "react-router-dom";
// import axios from "axios";
// import { Dialog } from "primereact/dialog";
// import { httpClient } from "../../HttpClient";
// import { keycloak, initKeycloak } from "../../keycloak";

// const CourseCard = ({ course }) => {

// const DropCourseToStudent = async () => {

// try {
//     const token = keycloak.token;
//     const response = await axios.get(
//     "https://localhost:7025/enrolled-course/drop-course/"+course.id,
//     {
//         headers: {
//         Authorization: `Bearer ${token}`,
//         },
//     }
//     );
//     window.location.reload();
// } catch (error) {
//     console.error("Error adding course:", error);
// }
// };

//   return (
//     <div
//       key={course.id}
//       className="course-card" // Handle click
//     >
      
//       <img src={course.imageUrl} alt={course.title} className="course-image" />
//       <h3 className="course-name">{course.title}</h3>
//       <p className="course-price">Price: ${course.price}</p>
//       <button onClick={DropCourseToStudent} className="button">
//         Drop Course
//       </button>
//     </div>
//   );
// };

// const StudentEnrolledCourses = () => {
//   const [courses, setCourses] = useState([]);
//   const [searchTerm, setSearchTerm] = useState("");
//   const [loading, setLoading] = useState(true);
//   const navigate = useNavigate(); // Hook for navigation
//   const [userRoles, setUserRoles] = useState([]);
//   const [username, setUsername] = useState("");
//   const [showRoleSelection, setShowRoleSelection] = useState(false);
//   const [selectedRole, setSelectedRole] = useState("");



//   useEffect(() => {
//     const fetchCourses = async () => {
//       try {
//         const token = keycloak.token;
//         const response = await axios.get(
//           "https://localhost:7025/enrolled-course/get-courses",
//           {
//             headers: {
//               Authorization: `Bearer ${token}`,
//             },
//           }
//         );
//         setCourses(response.data || []); // Ensure response data is set as an array
//         setLoading(false);
//      } catch (error) {
//         console.error("Error fetching courses:", error);
//         setLoading(false);
//       }
//     };

//     fetchCourses();
//   }, []);

//   const filteredCourses = courses.filter((course) =>
//     course.title.toLowerCase().includes(searchTerm.toLowerCase())
//   );

//   return (
//     <Card title="SMART ED" className="custom-card">
//       <div className="search-container">
//         <input
//           type="text"
//           placeholder="Search courses..."
//           value={searchTerm}
//           onChange={(e) => setSearchTerm(e.target.value)}
//           className="search-input"
//         />
//       </div>

//       <div className="courses-list">
//         {loading ? (
//           <p>Loading courses...</p>
//         ) : (
//           filteredCourses.map((course) => (
//             <CourseCard key={course.id} course={course} />
//           ))
//         )}
//       </div>
//     </Card>
//   );
// };

// export default StudentEnrolledCourses;
