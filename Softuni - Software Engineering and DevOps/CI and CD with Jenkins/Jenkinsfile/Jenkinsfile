pipeline {
    agent any
    stages {
        stage("NPM Install"){
            steps {
                bat 'cd Student-Registry-App && npm install'
            }
        }
        stage("NPM run tests") {
            steps {
                bat 'cd Student-Registry-App && npm test'
            }
        }
    }
}