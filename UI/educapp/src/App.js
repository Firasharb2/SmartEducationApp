import React, { useState, useEffect } from "react";
import "./App.css";
import "primereact/resources/themes/lara-light-indigo/theme.css";
import "primereact/resources/primereact.min.css";
import "/node_modules/primeflex/primeflex.css";
import { Button } from "primereact/button";
import { Dialog } from "primereact/dialog";
import { httpClient } from "./HttpClient";
import { keycloak, initKeycloak } from "./keycloak";
import { Card } from "primereact/card";
import { BrowserRouter as Router, Route, Routes, Link } from "react-router-dom";
import Footer from "./components/Footer";
import axios from "axios";
import CreateCourse from "./Pages/Course/CreateCourse";
import DisplayCourses from "./Pages/Course/DisplayCourses";
// import EditCourse from "./Pages/Course/EditCourse";
import ManageUsers from "./Admin/ManageUsers";
import CourseDetails from "./Pages/Course/CourseDetails";
import EnrollCourse from "./Pages/Course/EnrollCourse";
import StudentEnrolledCourses from "./Pages/Course/StudentEnrolledCourses";
function App() {
  const [username, setUsername] = useState("");
  const [userRoles, setUserRoles] = useState([]);
  const [showRoleSelection, setShowRoleSelection] = useState(false);
  const [selectedRole, setSelectedRole] = useState("");
  const [courses, setCourses] = useState([]); // State to hold the courses
  const [searchTerm, setSearchTerm] = useState(""); // State to hold the search term

  useEffect(() => {
    initKeycloak()
      .then((kc) => {
        httpClient.defaults.headers.common[
          "Authorization"
        ] = `Bearer ${kc.token}`;

        kc.loadUserInfo().then((userInfo) => {
          const roles = kc.tokenParsed.realm_access.roles || [];
          setUserRoles(roles);
          const fetchedUsername =
            userInfo?.name || userInfo?.preferred_username || "User";
          setUsername(fetchedUsername);

          // Check if user has none of the required roles
          if (
            !roles.includes("SuperAdmin") &&
            !roles.includes("Student") &&
            !roles.includes("Instructor")
          ) {
            setShowRoleSelection(true);
          }
        });

        kc.onTokenExpired = () => {
          console.log("Token expired");
        };
      })
      .catch(() => {
        console.error("Authentication Failed");
      });
  }, []);

  useEffect(() => {
    axios
      .get("/api/courses")
      .then((response) => {
        setCourses(response.data);
      })
      .catch((error) => {
        console.error("There was an error fetching the courses!", error);
      });
  }, []);

  const handleRoleApply = async () => {
    if (selectedRole) {
      const token = keycloak.token;

      console.log(token);
      // Make the API request
      if (selectedRole === "Student") {
        const responses = await axios.get(
          "https://localhost:7025/keycloak-management/get-users",
          {
            headers: {
              Authorization: `Bearer ${token}`,
            },
          }
        );

        const response = await axios.get(
          "https://localhost:7025/keycloak-management/assign-student-role",
          {
            headers: {
              Authorization: `Bearer ${token}`,
            },
          }
        );
      } else {
        const response = await axios.get(
          "https://localhost:7025/keycloak-management/assign-instructor-role",
          {
            headers: {
              Authorization: `Bearer ${token}`,
            },
          }
        );
      }
      window.location.reload();
    }
  };

  // Filter courses based on the search term
  const filteredCourses = courses.filter((course) =>
    course.name.toLowerCase().includes(searchTerm.toLowerCase())
  );

  return (
    <Router>
      <div className="App">
        <div className="layout">
          {/* Sidebar Menu */}
          <div className="sidebar">
            <h1>Smart-Ed</h1>
            <ul>
              <li>
                <Link to="/">Home</Link>
              </li>
              {userRoles.includes("SuperAdmin") && (
                <>
                  <li>
                    <Link to="src/Admin/ManageUsers">Manage Users</Link>
                  </li>
                </>
              )}
              {userRoles.includes("Instructor") && (
                <>
                  <li>
                    <Link to="/Pages/Course/CreateCourse">Create a Course</Link>
                  </li>
                  <li>
                    <Link to="/Pages/Course/DisplayCourses">My Courses</Link>
                  </li>
                </>
              )}
              {userRoles.includes("Student") && (
               <>  <li>
                  <Link to="/Pages/Course/DisplayCourses">Courses</Link>
                </li>
                <li>
                <Link to="/Pages/Course/StudentEnrolledCourses">Enrolled Courses</Link>
              </li>  </>
              )}
            </ul>
          </div>
          <div className="main-content">
            {/* Top Bar */}
            <div className="top-bar">
              <span>Welcome, {username}</span>
              <Button
                onClick={() => {
                  keycloak.logout({ redirectUri: "http://localhost:3000/" });
                }}
                className="p-button-danger"
                label="Logout"
              />
            </div>

            {/* Page Content */}
            <div className="page-content">  
              {/*All course content*/}
              <Routes>
                StudentEnrolledCourses
                <Route
                  path="/Pages/Course/CreateCourse"
                  element={<CreateCourse />}
                />
                <Route
                  path="/Pages/Course/DisplayCourses"
                  element={<DisplayCourses />}
                />
                
                <Route path="src/Admin/ManageUsers" element={<ManageUsers />} />
                <Route
                  path="/Pages/Course/CoursesDetails/:courseId"
                  element={<CourseDetails />}
                />
                <Route
                  path="/Pages/Course/StudentEnrolledCourses"
                  element={<StudentEnrolledCourses />}
                />
              
                <Route path="/Pages/Course/EnrolleCourse/:courseId" element={<EnrollCourse />} />
              </Routes>
              <Routes>
                <Route
                  path="/"
                  element={
                    <Card title="SMART ED Platform" className="custom-card">
                      <p>
                        Empowering Learning and Teaching: A Seamless Platform
                        for Instructors and Students, Combining Robust Features
                        with Modern Technology.
                      </p>
                      <img
                        src="https://static.vecteezy.com/system/resources/previews/001/410/879/large_2x/e-learning-online-education-futuristic-banner-vector.jpg"
                        alt="Description of Image"
                        style={{
                          width: "100%",
                          height: "400px",
                          borderRadius: "8px",
                        }}
                      />
                      <div className="courses-list">
                        {filteredCourses.map((Course) => (
                          <div key={Course.id} className="course-card">
                            <img
                              src={Course.imageUrl}
                              alt={Course.Title}
                              className="course-image"
                            />
                            <h3 className="course-name">{Course.Name}</h3>
                            <p className="course-price">
                              Price: ${Course.Price}
                            </p>
                          </div>
                        ))}
                      </div>
                    </Card>
                  }
                />
              </Routes>
            </div>
          </div>
        </div>

        {/* Footer - Added Here */}
        <Footer />

        {/* Role Selection Dialog */}
        <Dialog
          header="Select Your Role"
          visible={showRoleSelection}
          onHide={() => setShowRoleSelection(false)}
        >
          <p>Please select yor desired role:</p>
          <div>
            <Button
              label="Student"
              onClick={() => setSelectedRole("Student")}
            />
            <Button
              label="Instructor"
              onClick={() => setSelectedRole("Instructor")}
            />
          </div>
          <div>
            <Button label="Apply" onClick={handleRoleApply} />
          </div>
        </Dialog>
      </div>
    </Router>
  );
}

export default App;
