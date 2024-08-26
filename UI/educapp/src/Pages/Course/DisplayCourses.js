import React, { useState, useEffect } from "react";
import { Card } from "primereact/card";
import { useNavigate } from "react-router-dom";
import axios from "axios";
import { Dialog } from "primereact/dialog";
import { httpClient } from "../../HttpClient";
import { keycloak, initKeycloak } from "../../keycloak";

const CourseCard = ({ course, fetchCourses }) => {
  const navigate = useNavigate();

  const AddCourseToStudent = async () => {
    try {
      const token = keycloak.token;
      await axios.get(
        `https://localhost:7025/enrolled-course/add-course/${course.courseId}`,
        {
          headers: {
            Authorization: `Bearer ${token}`,
          },
        }
      );
      fetchCourses(); // Call fetchCourses to refresh the list
    } catch (error) {
      console.error("Error adding course:", error);
    }
  };

  return (
    <div key={course.courseId} className="course-card">
      <img src={course.imageUrl} alt={course.title} className="course-image" />
      <h3 className="course-name">{course.title}</h3>
      <p className="course-price">Price: ${course.price}</p>
      <button onClick={AddCourseToStudent} className="button">
        Add Course
      </button>
    </div>
  );
};

const DisplayCourses = () => {
  const [courses, setCourses] = useState([]);
  const [searchTerm, setSearchTerm] = useState("");
  const [loading, setLoading] = useState(true);
  const navigate = useNavigate();

  const fetchCourses = async () => {
    try {
      const token = keycloak.token;
      const response = await axios.get(
        "https://localhost:7025/course/get-courses",
        {
          headers: {
            Authorization: `Bearer ${token}`,
          },
        }
      );
      setCourses(response.data);
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
              key={course.courseId}
              course={course}
              fetchCourses={fetchCourses} // Pass fetchCourses as a prop
            />
          ))
        )}
      </div>
    </Card>
  );
};

export default DisplayCourses;





// import React, { useState, useEffect } from "react";
// import { Card } from "primereact/card";
// import { useNavigate } from "react-router-dom";
// import axios from "axios";
// import { Dialog } from "primereact/dialog";
// import { httpClient } from "../../HttpClient";
// import { keycloak, initKeycloak } from "../../keycloak";

// const CourseCard = ({ course,fetchCourses }) => {
//   const navigate = useNavigate();

//   const AddCourseToStudent = async () => {

//     try {
//       const token = keycloak.token;
//       const response = await axios.get(
//         "https://localhost:7025/enrolled-course/add-course/"+course.courseId,
//         {
//           headers: {
//             Authorization: `Bearer ${token}`,
//           },
//         }
//       );
//       fetchCourses();
//     } catch (error) {
//       console.error("Error adding course:", error);
//     }
//   };

//   return (
//     <div
//       key={course.courseId}
//       className="course-card" // Handle click
//     >
      
//       <img src={course.imageUrl} alt={course.title} className="course-image" />
//       <h3 className="course-name">{course.title}</h3>
//       <p className="course-price">Price: ${course.price}</p>
//       <button onClick={AddCourseToStudent} className="button">
//         Add Course
//       </button>
//     </div>
//   );
// };

// const DisplayCourses = () => {
//   const [courses, setCourses] = useState([]);
//   const [searchTerm, setSearchTerm] = useState("");
//   const [loading, setLoading] = useState(true);
//   const navigate = useNavigate(); // Hook for navigation
//   const [userRoles, setUserRoles] = useState([]);
//   const [username, setUsername] = useState("");
//   const [showRoleSelection, setShowRoleSelection] = useState(false);
//   const [selectedRole, setSelectedRole] = useState("");



//   const fetchCourses = async () => {
//     try {
//       const token = keycloak.token;
//       const response = await axios.get(
//         "https://localhost:7025/course/get-courses",
//         {
//           headers: {
//             Authorization: `Bearer ${token}`,
//           },
//         }
//       );
//       setCourses(response.data);
//       setLoading(false);
//     } catch (error) {
//       console.error("Error fetching courses:", error);
//       setLoading(false);
//     }
//   };


//   useEffect(() => {

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
//             <CourseCard key={course.courseId} course={course} />
//           ))
//         )}
//       </div>
//     </Card>
//   );
// };

// export default DisplayCourses;
