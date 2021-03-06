﻿/*! \file UProcess.h
    \brief 包含了一些进程相关的函数。
    这里函数使用Unicode,这样不同系统的语言

    \date 2011-9-6
*/
#ifndef UNICORE_UPROCESS_H
#define UNICORE_UPROCESS_H

#include <string>

#define WIN32_LEAN_AND_MEAN
#include "Windows.h"

#define AUTO_LINK_LIB_NAME "UniCore"
#include "AutoLink.h"

namespace uni
{

    
//! 授予当前进程调试权限。
/*!
    \return 是否成功。
*/
bool EnableDebugPrivilege();

//! 检查文件是否存在.
/*!
    \param fileName 文件路径,可以是完整路径也可以是相对路径,该参数会传递给ifstream.
    \return 文件是否存在.
    通过尝试打开文件来判断文件是否存在.
*/
bool FileExists(const std::string &fileName);
bool FileExists(const std::wstring &fileName);

//! 获得当前进程所在路径。
/*!
    \return 当前进程的可执行文件所在路径,失败则返回空的字符串.返回结果始终以L"\\"结尾.
*/
std::wstring GetCurrentProcessDirectory();


//! 获得进程名。
/*!
    \param pid 进程id。
    \return 进程名。
*/
std::wstring GetProcessName(unsigned int pid);

//! 设置AccessToken的权限。
/*!
    \param hToken AccessToken句柄，需要有TOKEN_ADJUST_PRIVILEGES访问权限。
    \param privilege 特权常量(Privilege Constants)。
    \param enabled 该参数为是时，设置特权；为否时，删除特权。
    \return 是否设置成功。
*/
bool SetTokenPrivilege(HANDLE hToken,wchar_t *privilege,bool enabled);


//! 将LocaleID转换成RFC1766字符串.
/*!
    \param lcid LocaleID, 通过GetSystemDefaultLCID之类的函数获得.
    \return 成功则返回lcid对应的RFC1766字符串, 例如"en","zh","tw"之类的语言缩写.
                 失败则返回空字符串.
    该函数只是尝试进行转换, 失败的可能性较大.
*/
std::wstring LCIDToRFC1766(LCID lcid);

//! 获得指定进程的CPU使用率.
/*! 
    \param pid 要得到CPU使用率的进程名.
	\return CPU使用率,取值从0.0到1.0.
*/
float GetCPUUsage(int pid);

//! 检查指定的进程是32位还是64位.
/*!
	未实现,始终返回32.
*/
int GetProcessBitness(int pid);


}//namespace uni

#endif//UNICORE_UPROCESS_H