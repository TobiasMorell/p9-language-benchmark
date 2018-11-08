#include <cmath>
#include <boost/numeric/ublas/vector.hpp>
#include <boost/numeric/ublas/io.hpp>
#include <array>

#ifndef NATIVE_TESTS_H
#define NATIVE_TESTS_H

using namespace boost::numeric::ublas;

vector<double> get2DVector(double initial){
    vector<double> vec (2);
    vec[0] = initial;
    vec[1] = initial;
    return vec;
}

vector<double> get3DVector(double initial){
    vector<double> vec (3);
    vec[0] = initial;
    vec[1] = initial;
    vec[2] = initial;
    return vec;
}

static double sestoft(int input){
    double x = 1.1 * (double) (input & 0xFF);
    return x * x * x * x * x * x * x * x * x * x * x * x * x * x * x * x * x * x * x * x;
}

static double sestoftMath(int input){
    double x = 1.1 * (double) (input & 0xFF);
    return pow(x, 20);
}

static double scaleVector2D(int scalar){
    vector<double> v = get2DVector(1);
    v * scalar;
    return v.size();
}

static double scaleVector3D(int scalar){
    vector<double> v = get3DVector(1);
    v * scalar;
    return v.size();
}

static double multiplyVector2D(int i){
    vector<double> v1 = get2DVector(1);
    vector<double> v2 = get2DVector(i);
    boost::numeric::ublas::element_prod(v1, v2);
    return v1.size();
}

static double multiplyVector3D(int i){
    vector<double> v1 = get3DVector(1);
    vector<double> v2 = get3DVector(i);
    boost::numeric::ublas::element_prod(v1, v2);
    return v1.size();
}

static double translateVector2D(int i){
    vector<double> v1 = get2DVector(1);
    v1[0] += i;
    return v1.size();
}

static double translateVector3D(int i){
    vector<double> v1 = get3DVector(1);
    v1[0] += i;
    return v1.size();
}

static double substractVector2D(int i){
    vector<double> v1 = get2DVector(i);
    vector<double> v2 = get2DVector(1);
    v1 -= v2;
    return v1.size();
}

static double substractVector3D(int i){
    vector<double> v1 = get3DVector(i);
    vector<double> v2 = get3DVector(1);
    v1 -= v2;
    return v1.size();
}

static double lengthVector2D(int i){
    vector<double> v1 = get2DVector(i);
    return v1.size();
}

static double lengthVector3D(int i){
    vector<double> v1 = get3DVector(i);
    return v1.size();
}

static double dotproduct2D(int i){
    vector<double> v1 = get2DVector(1);
    vector<double> v2 = get2DVector(i);
    return boost::numeric::ublas::inner_prod(v1, v2);
}

static double dotproduct3D(int i){
    vector<double> v1 = get3DVector(1);
    vector<double> v2 = get3DVector(i);
    return boost::numeric::ublas::inner_prod(v1, v2);
}

static double prime100Test(int number){
    const int realNumber = 100;
    bool A[realNumber + 1];


    for (int i = 2; i < realNumber; i++)
    {
        A[i] = true;
    }

    for (int i = 2; i < sqrt(realNumber); i++)
    {
        if(A[i])
        {
            auto iPow = (int)pow(i, 2);
            auto num = 0;

            for (int j = 0; j < realNumber; j = iPow + num * i)
            {
                A[i] = false;
                num++;
            }
        }
    }

    auto primes = std::vector<int>();
    for (int i = 0; i < (sizeof(A)/sizeof(*A)); i++)
    {
        if (A[i])
            primes.push_back(i);
    }

    return primes[primes.size() - 1] & number;
}


int rand_num = rand() % 100;
static double memTest(int i){
    std::array<double, 100000> arry{0};
    return arry[(i & 0xFF) + rand_num];
}

#endif //NATIVE_TESTS_H